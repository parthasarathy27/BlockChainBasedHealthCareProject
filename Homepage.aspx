<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h3>About Our Project</h3>
<p style ="text-align : justify ;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;With the popularity of IoT devices and cloud technology in the medical industry. Sharing
EHRs (Electronic Health Records) among medical institutions improves the accuracy of medical diagnosis
and promotes the development of public medical. However, it is diffcult to share EHRs among hospitals,
and patients typically don't know about the usage of their health records. In this project, we propose
a patient-controlled EHRs sharing scheme based on cloud computing collaborating blockchain technology. The medical abstract and the access strategy are stored in the blockchain to avoid being tampered
with. 
</p>
    <p style ="text-align : justify ;">
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To achieve the ne-grained access control, we propose the attribute-based encryption scheme and
multi-keyword encryption scheme to encrypt EHRs. Moreover, we proposed a node-state-checkable Practical
Byzantine Fault Tolerance consensus algorithm (sc-PBFT) to prevent the Byzantine nodes from sneaking
into the consortium blockchain. First, we check the state of the elected master node to avoid the master node
having any malicious records. Then, using pre-prepared, prepare, and commit processes to complete the
consensus request submitted by the client.</p>
    <p style ="text-align : justify ;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At last, the proposed consensus algorithm evaluates the state of
the master node according to the completion of the three-stage process to reduce the impact of the malicious
node on the whole consortium blockchain. By doing this, the malicious node will be marked and isolated into
the isolation area.The experimental results show that the proposed sc-PBFT algorithm has better handling
capability and lower consensus latency. Compared with the PBFT algorithm in the case of Byzantine nodes,
sc-PBFT not only improves the robustness of the consortium blockchain network but also improves the
handling capability.
</p>
</asp:Content>

